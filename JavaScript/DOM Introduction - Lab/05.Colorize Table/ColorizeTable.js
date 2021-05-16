function colorize() {

    [...document.querySelectorAll('tr:nth-child(even)')]
    .forEach(x => x.style.background = 'Teal' )
    
}