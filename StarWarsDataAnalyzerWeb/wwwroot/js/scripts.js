document.addEventListener('DOMContentLoaded', () => {
    const showDataButton = document.getElementById('showData');
    const showDashboardButton = document.getElementById('showDashboard');
    const dataSection = document.getElementById('dataSection');
    const dashboardSection = document.getElementById('dashboardSection');
    const buttons = document.querySelector('.fixed-buttons');

    // Inicializa a visibilidade
    if (showDataButton && showDashboardButton && dataSection && dashboardSection) {
        showDataButton.addEventListener('click', () => {
            dataSection.style.display = 'block';
            dashboardSection.style.display = 'none';
        });

        showDashboardButton.addEventListener('click', () => {
            dataSection.style.display = 'none';
            dashboardSection.style.display = 'block';
        });
    }

    // Função para esconder ou mostrar os botões fixos
    let lastScrollTop = 0;
    window.addEventListener('scroll', () => {
        let currentScrollTop = window.pageYOffset || document.documentElement.scrollTop;

        if (currentScrollTop > lastScrollTop) {
            // Rolando para baixo
            buttons.classList.add('hidden');
        } else {
            // Rolando para cima
            buttons.classList.remove('hidden');
        }

        lastScrollTop = currentScrollTop <= 0 ? 0 : currentScrollTop; // Para não permitir rolagem negativa
    });
});
