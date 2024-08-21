document.addEventListener('DOMContentLoaded', function () {
    const showDataButton = document.getElementById('showData');
    const showDashboardButton = document.getElementById('showDashboard');
    const dataSection = document.getElementById('dataSection');
    const dashboardSection = document.getElementById('dashboardSection');

    showDataButton.addEventListener('click', function () {
        dataSection.style.display = 'block';
        dashboardSection.style.display = 'none';
    });

    showDashboardButton.addEventListener('click', function () {
        dataSection.style.display = 'none';
        dashboardSection.style.display = 'block';
        // Aqui você pode adicionar a inicialização dos gráficos com D3.js
        initializeCharts();
    });

    function initializeCharts() {
        // Código para inicializar e desenhar os gráficos com D3.js
    }
});
