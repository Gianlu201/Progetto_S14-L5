let buttons = document.getElementsByClassName("shoesImg");
let bigImg = document.getElementById("bigImg")

if (buttons.length > 0) {
    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener("mouseover", () => {
            bigImg.setAttribute("src", buttons[i].src);
        })
    }
}