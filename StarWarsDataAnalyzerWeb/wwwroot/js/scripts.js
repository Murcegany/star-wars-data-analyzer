document.addEventListener('DOMContentLoaded', () => {
    const showDataButton = document.getElementById('showData');
    const showDashboardButton = document.getElementById('showDashboard');
    const dataSection = document.getElementById('dataSection');
    const dashboardSection = document.getElementById('dashboardSection');
    const buttons = document.querySelector('.fixed-buttons');
    const loadDataButton = document.getElementById('loadData'); // Botão para carregar dados
    const planetDataDiv = document.getElementById('planetData'); // Div para exibir dados dos planetas

    // Inicializa a visibilidade
    if (showDataButton && showDashboardButton && dataSection && dashboardSection) {
        showDataButton.addEventListener('click', () => {
            dataSection.style.display = 'block';
            dashboardSection.style.display = 'none';
        });

        showDashboardButton.addEventListener('click', () => {
            dataSection.style.display = 'none';
            dashboardSection.style.display = 'block';
            loadDashboardData(); // Carregar dados do dashboard ao mostrar
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

    // Função para buscar e exibir dados dos planetas
    async function loadPlanetData() {
        try {
            const response = await fetch('/api/planets');
            const planets = await response.json();
            displayPlanets(planets);
        } catch (error) {
            console.error('Error loading planet data:', error);
            planetDataDiv.innerHTML = '<p>Error loading data</p>';
        }
    }

    function displayPlanets(planets) {
        planetDataDiv.innerHTML = ''; // Limpa dados anteriores
        if (planets.length === 0) {
            planetDataDiv.innerHTML = '<p>No data available</p>';
            return;
        }

        const table = document.createElement('table');
        table.innerHTML = `
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Climate</th>
                    <th>Terrain</th>
                    <th>Population</th>
                </tr>
            </thead>
            <tbody>
                ${planets.map(planet => `
                    <tr>
                        <td>${planet.name}</td>
                        <td>${planet.climate}</td>
                        <td>${planet.terrain}</td>
                        <td>${planet.population}</td>
                    </tr>
                `).join('')}
            </tbody>
        `;
        planetDataDiv.appendChild(table);
    }

    // Função para buscar e exibir dados para o dashboard
    async function loadDashboardData() {
        try {
            const response = await fetch('/api/planets');
            const planets = await response.json();
            renderCharts(planets);
        } catch (error) {
            console.error('Error loading dashboard data:', error);
        }
    }

    function renderCharts(planets) {
        const ctx1 = document.getElementById('chart1').getContext('2d');
        const ctx2 = document.getElementById('chart2').getContext('2d');
        // Adicione mais contextos de gráficos se necessário

        // Example Chart 1: Population by Climate
        const climateData = {};
        planets.forEach(planet => {
            climateData[planet.climate] = (climateData[planet.climate] || 0) + parseInt(planet.population);
        });
        new Chart(ctx1, {
            type: 'bar',
            data: {
                labels: Object.keys(climateData),
                datasets: [{
                    label: 'Population by Climate',
                    data: Object.values(climateData),
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                }]
            }
        });

        // Example Chart 2: Population by Terrain
        const terrainData = {};
        planets.forEach(planet => {
            terrainData[planet.terrain] = (terrainData[planet.terrain] || 0) + parseInt(planet.population);
        });
        new Chart(ctx2, {
            type: 'pie',
            data: {
                labels: Object.keys(terrainData),
                datasets: [{
                    label: 'Population by Terrain',
                    data: Object.values(terrainData),
                    backgroundColor: Object.keys(terrainData).map(() => 'rgba(54, 162, 235, 0.2)'),
                    borderColor: Object.keys(terrainData).map(() => 'rgba(54, 162, 235, 1)'),
                    borderWidth: 1
                }]
            }
        });

    }

    // Adiciona evento de clique ao botão de carregar dados
    if (loadDataButton) {
        loadDataButton.addEventListener('click', loadPlanetData);
    }
});
