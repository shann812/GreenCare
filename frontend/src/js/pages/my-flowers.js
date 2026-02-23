import { FlowerService } from "../services/flowerService.js";
import { UIHelper } from "../shared/UIHelper.js";

const CARDS_PER_PAGE = 8;
let hasMoreFlowers = true;
let isLoading = false;
let currentPage = 0;

const flowersContainer = document.getElementById('flowers-container');
const loadMoreBtn = document.getElementById('load-more-btn');

document.addEventListener('DOMContentLoaded', async function() {
    loadFlowerCards();

    if (loadMoreBtn) {
        loadMoreBtn.addEventListener('click', loadFlowerCards);
    }
});

async function loadFlowerCards(){
    try{
        if (isLoading || !hasMoreFlowers) return;

        isLoading = true;
        if (loadMoreBtn) loadMoreBtn.disabled = true;

        const result = await FlowerService.getUserFlowerCards(currentPage, CARDS_PER_PAGE);
        const flowerCards = result.data;
        if(flowerCards.length === 0)
        {
            hasMoreFlowers = false;
            if (currentPage === 0) 
                showEmptyState();
            return;
        }

        flowerCards.forEach(card => {
            const cardEl = createFlowerCard(card);
            flowersContainer.appendChild(cardEl);
        });

        currentPage++;
        if (flowerCards.length < CARDS_PER_PAGE) {
            hasMoreFlowers = false;
            if (loadMoreBtn) loadMoreBtn.style.display = 'none';
        }
    }
    catch(error){
        UIHelper.showErrors(error);
    }
    finally {
        isLoading = false;
        if (loadMoreBtn) loadMoreBtn.disabled = false;
    }
}

function createFlowerCard(cardData)
{
    const cardEl = document.createElement('div');
    cardEl.className = 'flower-card';

    const now = new Date();

    let daysSinceWaterLabel = 'never';
    let waterStatus = '';
    if(cardData.lastWatering != null){
        const lastWater = new Date(cardData.lastWatering);
        const daysSinceWater = Math.floor((now - lastWater) / (1000 * 60 * 60 * 24));
        daysSinceWaterLabel = `${daysSinceWater} days`;

        if (daysSinceWater >= cardData.wateringIntervalDays) {
            waterStatus = 'overdue';
        } else if (daysSinceWater >= cardData.wateringIntervalDays - 1) {
            waterStatus = 'soon';
        }
    }
    
    let daysSinceFertLabel = 'never';
    let fertStatus = '';
    if(cardData.lastFertilizing != null){
        const lastFert = new Date(cardData.lastFertilizing);
        const daysSinceFert = Math.floor((now - lastFert) / (1000 * 60 * 60 * 24));
        daysSinceFertLabel = `${daysSinceFert} days`;

        if (daysSinceFert >= cardData.fertilizingIntervalDays) {
            fertStatus = 'overdue';
        } else if (daysSinceFert >= cardData.fertilizingIntervalDays - 1) {
            fertStatus = 'soon';
        }
    }

    cardEl.innerHTML = `
        <div class="flower-image-wrapper">
            <img class="flower-image" src="https://localhost:7051${cardData.imageUrl}">
            ${cardData.onModeration ? '<span class="badge-moderation">On moderation</span>' : ''}
        </div>
        
        <div class="flower-info">
            <h3 class="flower-name">${cardData.name}</h3>
            <p class="flower-type">${cardData.type}</p>
            
            <div class="flower-statuses">
                <span class="status-badge status-water ${waterStatus}">
                    Last watering: ${daysSinceWaterLabel}
                </span>
                <span class="status-badge status-fert ${fertStatus}">
                    Last fertilizing: ${daysSinceFertLabel}
                </span>
            </div>

            <p class="flower-privacy">
                ${cardData.isPrivate ? 'Private' : 'Public'}
            </p>

            <div class="flower-actions">
                <button class="btn-action btn-water" data-id="${cardData.id}" title="I watered">
                    Watered
                </button>
                <button class="btn-action btn-fertilize" data-id="${cardData.id}" title="I fertilized">
                    Fertilized
                </button>
            </div>
        </div>
    `;

    cardEl.querySelector('.btn-water')?.addEventListener('click', () => handleWatering(cardData.id));
    cardEl.querySelector('.btn-fertilize')?.addEventListener('click', () => handleFertilizing(cardData.id));

    return cardEl;
}

function showEmptyState() {
    flowersContainer.innerHTML = `
        <div class="empty-state">
            <p>You have no flower yet</p>
            <a href="/add-flower.html" class="btn btn-primary">Add your first flower</a>
        </div>
    `;
}

//watering btn
//fert btn