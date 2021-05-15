function sumTable() {

    const element = [...document.querySelectorAll('td:nth-child(even)')]
        .reduce((acc, c) => {

            if (!isNaN(c.textContent)) {

                return acc + Number(c.textContent)
            }

        }, 0)

    document.querySelector('#sum').textContent = element

}