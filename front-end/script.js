const listarTimes = document.getElementById('times-lista');
const apiUrl = 'http://localhost:5271/times';

const getTimes = async () => {
    try {
        const response = await fetch(apiUrl, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        
        if(!response.ok) {
            throw new Error('Erro ao buscar os times!');
        }
        
        const times = await response.json(); 
        
        times.forEach((time) =>{
            const newTr = document.createElement('tr');
            
            const tdId = document.createElement('td');
            tdId.innerText = time.id; 
            newTr.appendChild(tdId);

            const tdNome = document.createElement('td');
            tdNome.innerText = time.nome;
            newTr.appendChild(tdNome);
            
            const tdCidade = document.createElement('td');
            tdCidade.innerText = time.cidade;
            newTr.appendChild(tdCidade);

            const tdTitulosBrasileiros = document.createElement('td');
            tdTitulosBrasileiros.innerText = time.titulosBrasileiros;
            newTr.appendChild(tdTitulosBrasileiros);

            const tdTitulosMundiais = document.createElement('td');
            tdTitulosMundiais.innerText = time.titulosMundiais;
            newTr.appendChild(tdTitulosMundiais);
            newTr.classList.add('times-lista-item');
            listarTimes.appendChild(newTr);
        });
    }catch (error) {        
        listarTimes.innerText = `${error.message}`;
    }
}

const getTimesById = async (id) => {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if(!response.ok) {
            throw new Error('Erro ao buscar os times!');
        }

        const times = await response.json();

        times.forEach((time) =>{
            const newTr = document.createElement('tr');

            const tdId = document.createElement('td');
            tdId.innerText = time.id;
            newTr.appendChild(tdId);

            const tdNome = document.createElement('td');
            tdNome.innerText = time.nome;
            newTr.appendChild(tdNome);

            const tdCidade = document.createElement('td');
            tdCidade.innerText = time.cidade;
            newTr.appendChild(tdCidade);

            const tdTitulosBrasileiros = document.createElement('td');
            tdTitulosBrasileiros.innerText = time.titulosBrasileiros;
            newTr.appendChild(tdTitulosBrasileiros);

            const tdTitulosMundiais = document.createElement('td');
            tdTitulosMundiais.innerText = time.titulosMundiais;
            newTr.appendChild(tdTitulosMundiais);
            newTr.classList.add('times-lista-item');
            listarTimes.appendChild(newTr);
        });
    }catch (error) {
        listarTimes.innerText = `${error.message}`;
    }
}
getTimes();





