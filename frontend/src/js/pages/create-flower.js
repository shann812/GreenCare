import { FlowerService } from "../services/flowerService.js";
import { UIHelper } from "../shared/UIHelper.js";

const addFlowerForm = document.getElementById('addFlowerForm');

const flowerName = document.getElementById('flowerName');
const description = document.getElementById('description');
const flowerTypeSelect = document.getElementById('flowerTypeSelect');
const seasonCheckboxes = document.querySelectorAll('.season-checkboxes input[type="checkbox"]');
const wateringInterval = document.getElementById('wateringInterval');
const fertilizingInterval = document.getElementById('fertilizingInterval');
const isPrivateCheckbox = document.getElementById('isPrivateCheckbox');
const imageInput = document.getElementById('flowerImage');

addFlowerForm.addEventListener('submit', async function(e) {
    e.preventDefault();

    try{
        const formData = createFormData();
        await FlowerService.createFlower(formData);
        UIHelper.showSuccess('Flower added');
        //to my flowers
    }
    catch(error){
        UIHelper.showErrors(error);
    }
})

document.addEventListener('DOMContentLoaded', async function() {
    await loadFlowerTypes();

    const preview = document.getElementById('imagePreview');
    const previewPlaceholder = document.getElementById('previewPlaceholder');

    if (!imageInput) 
        return;

    imageInput.addEventListener('change', function(event) {
        const file = event.target.files[0];
        
        if (file) {
            const reader = new FileReader();
            
            reader.onload = function(e) {
                preview.src = e.target.result;
                preview.style.display = 'block';
                if (previewPlaceholder) {
                    previewPlaceholder.style.display = 'none';
                }
            }
            
            reader.readAsDataURL(file);
        } else {
            preview.src = '#';
            preview.style.display = 'none';
            if (previewPlaceholder) {
                previewPlaceholder.style.display = 'block';
            }
        }
    });
});


async function loadFlowerTypes(){
    try{
        const result = await FlowerService.getFlowerTypes();
        const types = result.data;
        types.forEach(typeName => {
            const option = document.createElement('option');
            option.value = typeName;
            option.textContent = typeName;
            flowerTypeSelect.appendChild(option);
        });
    }
    catch(error){
        UIHelper.showErrors(error);
        console.log(error);
    }
}

function createFormData(){
    const formData = new FormData();
    if (imageInput.files.length > 0)
        formData.append("flowerImg", imageInput.files[0]);

    const selectedSeasons = Array.from(seasonCheckboxes) 
        .filter(cb => cb.checked) 
        .map(cb => cb.value);

    formData.append('name', flowerName.value);
    formData.append('description', description.value);
    formData.append('type', flowerTypeSelect.value);
    selectedSeasons.forEach(season => {
        formData.append('bloomSeasons', season);
    });

    if (wateringInterval.value)
        formData.append('wateringInterval', wateringInterval.value);

    if (fertilizingInterval.value)
        formData.append('fertilizingInterval', fertilizingInterval.value);
    
    formData.append('isPrivate', isPrivateCheckbox.checked ? "true" : "false");

    return formData;
}