// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {

    const menu = document.querySelector(".menu-dropdown");
    const button = document.getElementById("menuDropdownButton");
    const content = document.getElementById("menuDropdownContent");

    if (!menu || !button || !content) {
        return;
    }


    // Abrir / fechar menu
    button.addEventListener("click", function (event) {

        event.stopPropagation();

        const aberto = menu.classList.toggle("open");

        button.setAttribute(
            "aria-expanded",
            aberto.toString()
        );

    });


    // Impede que clicar dentro do menu feche imediatamente
    content.addEventListener("click", function (event) {

        event.stopPropagation();

    });


    // Fecha quando clicar fora
    document.addEventListener("click", function () {

        menu.classList.remove("open");

        button.setAttribute(
            "aria-expanded",
            "false"
        );

    });


    // Fecha com ESC
    document.addEventListener("keydown", function (event) {

        if (event.key === "Escape") {

            menu.classList.remove("open");

            button.setAttribute(
                "aria-expanded",
                "false"
            );

        }

    });

});