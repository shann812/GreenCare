document.addEventListener('DOMContentLoaded', function() {
    const imageInput = document.getElementById('flowerImage');
    const preview = document.getElementById('imagePreview');
    const previewPlaceholder = document.getElementById('previewPlaceholder');

    if (!imageInput) {
        console.error('flowerImage input not found!');
        return;
    }

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