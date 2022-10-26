
function solve(array, begining, end) {

    let result = [];

   let startingIndex = array.indexOf(begining);
   let endingIndex;

    for (let i = startingIndex; i < array.length; i++) {

        result.push(array[i]);

       if(array[i] == end){

             break;
       }
    }

    return result;
}
console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
))
console.log(solve(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));
