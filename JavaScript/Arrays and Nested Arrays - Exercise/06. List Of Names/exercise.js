function solve(array) {

    return array.sort((a, b) => a.localeCompare(b))
        .map((value, index) => value = `${index + 1}.${value}`)
        .join('\n');

}

console.log(solve(["John", "Bob", "Christina", "Ema"]));

