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
    const lastWater = new Date(cardData.lastWatering);
    const lastFert = new Date(cardData.lastFertilizing);

    const daySinceWater = Math.floor((now - lastWater) / (1000 * 60 * 60 * 24));
    const daySinceFert = Math.floor((now - lastFert) / (1000 * 60 * 60 * 24));

    //if() add style

    cardEl.innerHTML = `
        <img src="https://localhost:7051${cardData.imageUrl}" /><br>
        <h3>${cardData.name}</h3>
        <p>${cardData.type}</p>
        <p>${cardData.isPrivate ? "private" : "public"}</p>
        <p>${cardData.lastWatering ?? "never"}</p>
        <p>${cardData.lastFertilizing ?? "never"}</p>
        
    `;
        //и тут ещё две кнопки надо типо полил и удобрил
    
    if(cardData.onModeration){
        cardEl.innerHTML = `
            <p>on moderation</p>
        `;
    };

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