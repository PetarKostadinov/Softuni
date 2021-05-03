function solve(array) {

    return array.reduce((acc, c) => {

        if (acc.length === 0 || acc[acc.length - 1] <= c) {
            acc.push(c);
        }
        return acc
    }, []);

}

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));

console.log(solve([1,
    2,
    3,
    4]
));
