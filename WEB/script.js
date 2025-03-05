document.addEventListener("DOMContentLoaded", function () {
    let cursorImg = document.createElement("img");
    cursorImg.src = "Mys.png";
    cursorImg.style.position = "absolute";
    cursorImg.style.width = "32px";
    cursorImg.style.height = "32px";
    cursorImg.style.pointerEvents = "none"; 
    cursorImg.style.zIndex = "9999";
    document.body.appendChild(cursorImg);

    document.onmousemove = (e) => {
        cursorImg.style.left = e.pageX + "px";
        cursorImg.style.top = e.pageY + "px";
    };
});
