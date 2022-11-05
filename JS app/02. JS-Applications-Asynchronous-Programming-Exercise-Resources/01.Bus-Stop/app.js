async function getInfo() {
    
    let input = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${input}`;


    let divStopName = document.getElementById('stopName');
    let ulBuses = document.getElementById('buses');

    try {

        divStopName.textContent = 'Loading...'

        ulBuses.replaceChildren();
        
        const res = await fetch(url);

        if(res.status !== 200) {

             throw new Error('Not found')

        }

        const data = await res.json();

        divStopName.textContent = data.name;

        Object.entries(data.buses).forEach(x => {

            let li = document.createElement('li')
            li.textContent = `Bus ${x[0]} arrives in ${x[1]} minutes`
            ulBuses.appendChild(li)
        })

    } catch (error) {

        divStopName.textContent = 'Error'
        
        
    }

}