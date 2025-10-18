document.addEventListener('DOMContentLoaded', function() {
    const hisModel = document.getElementById('christImage');
    const modalImage = document.getElementById('modalImage');
    const captionText = document.getElementById('caption');
    const span = document.getElementsByClassName('close')[0];

   
    const galleryImages = document.querySelectorAll('.gallerycontainer img');


    galleryImages.forEach(img => {
        img.addEventListener('click', function() {
            hisModel.style.display = "block";
            modalImage.src = this.src;
            const details = this.getAttribute('data-details');
            captionText.innerHTML = details || this.alt;
        });
    });

    span.onclick = function() { 
        hisModel.style.display = "none";
    }
    window.onclick = function(event) {
        if (event.target == hisModel) {
            hisModel.style.display = "none";
        }
    }
});