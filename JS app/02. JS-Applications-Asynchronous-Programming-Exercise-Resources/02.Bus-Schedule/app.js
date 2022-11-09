function solve() {

    let label = document.querySelector('#info span');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let stop = {

        next: 'depot'
    };

    async function depart() {

        let url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;
        let res = await fetch(url);

        if (res.status !== 200) {

            departBtn.disabled = true;
            arriveBtn.disabled = true;
            label.textContent = 'Error'
        }

        stop = await res.json();

        label.textContent = `Next stop ${stop.name}`;

        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    async function arrive() {

        label.textContent = `Arriving at ${stop.name}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;

    }

    return {
        depart,
        arrive
    };
}

let result = solve();