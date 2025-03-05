function toggleSection(sectionId) {
    var list = document.getElementById('list' + sectionId.slice(-1));
    if (list.style.display === 'none') {
        list.style.display = 'block';
    } else {
        list.style.display = 'none';
    }
}

function openImage(src, caption, description) {
    var modal = document.getElementById("modal");
    var modalImg = document.getElementById("modalImg");
    var captionText = document.getElementById("caption");
    var descriptionText = document.getElementById("description");
    var span = document.getElementsByClassName("close")[0];
    modal.style.display = "block";
    modalImg.src = src;
    captionText.innerHTML = caption;
    descriptionText.innerHTML = description;
    span.onclick = function() {
        modal.style.display = "none";
    };
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    };
}