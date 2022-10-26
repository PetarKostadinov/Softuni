function solve(fruit, weight, price){
    const weightKg = weight / 1000;
    const moneyForFruits =  weightKg * price;

    return `I need $${moneyForFruits.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`;
    
}
console.log(solve('orange', 2500, 1.80));
console.log(solve('apple', 1563, 2.35));