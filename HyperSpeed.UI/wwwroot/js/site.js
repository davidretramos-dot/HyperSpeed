// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("site.js carregado");
document.addEventListener("DOMContentLoaded", function () {
    console.log('DOMContentLoaded fired for site.js');

    const menu = document.querySelector(".menu-dropdown");
    const button = document.getElementById("menuDropdownButton");
    const content = document.getElementById("menuDropdownContent");

    console.log({ menu, button, content });

    if (!menu || !button || !content) {
        return;
    }


    // Abrir / fechar menu
    button.addEventListener("click", function (event) {

        event.stopPropagation();

        const aberto = menu.classList.toggle("open");

        console.log('menu toggle, aberto=', aberto);

        button.setAttribute(
            "aria-expanded",
            aberto.toString()
        );

        // Posiciona o dropdown como fixed na viewport para evitar problemas de clipping
        if (aberto) {
            try {
                const rect = button.getBoundingClientRect();

                // Definir como fixed e posicionar abaixo do botão
                content.style.position = 'fixed';
                content.style.left = Math.max(8, rect.left) + 'px';
                content.style.top = (rect.bottom + 8) + 'px';
                // Garante largura mínima
                content.style.minWidth = Math.max(210, rect.width) + 'px';
            }
            catch (e) {
                console.error('Erro ao posicionar dropdown:', e);
            }
        }
        else {
            // Remove estilos inline quando fechar
            content.style.position = '';
            content.style.left = '';
            content.style.top = '';
            content.style.minWidth = '';
        }

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