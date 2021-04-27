
function solve(number, ...command) {

    number = Number(number);

    let collection = [];

    for (i = 0; i < command.length; i++) {
        if (command[i] == 'chop') {
            collection.push(number /= 2);
        }
        else if (command[i] == 'dice') {
            collection.push(number = Math.sqrt(number));
        }
        else if (command[i] == 'spice') {
            collection.push(number += 1);
        }
        else if (command[i] == 'bake') {
            collection.push(number *= 3);
        }
        else if (command[i] == 'fillet') {
            number *= 0.8;
            collection.push(number.toFixed(1));
        }

    }

    return collection.join('\n');
}

console.log(solve('32', 'chop', 'chop', 'chop', 'chop', 'chop'));
console.log(solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));

