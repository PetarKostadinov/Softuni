

 //distructuring  - Rest operator:

 //let[... myArr] = arr  // use to clone array


 //Spread operator:

 //let arr = [1, 2, 3];

 //let myArr1 = [...arr];


 //SLICE  -> NonMutator
 let arr1 = [5, 2, 3, 10, 1, 4, 9, 8, 7, 6];

 let myCloneArr = arr1.slice(); // use to clone array nonMutator

console.log(myCloneArr);

 let myArr2 = arr1.slice(2, -2);  
 console.log(arr1);
 console.log(myArr2);

  //SPLICE -> Mutator
 let myArr3 = arr1.splice(1, 5); 
 console.log(arr1);
 console.log(myArr3);
 

 //SORT ARRAY  String-  .sort() -> alfabeticaly ordeer

 let StrArr = ['PEsho', 'Ani', 'Gosho', 'Bobi'];

 console.log(StrArr.sort());

 //SORT ARRAY Numbber

 let arr = [5, 2, 3, 10, 1, 4, 9, 8, 7, 6]
 arr.sort((a, b) => a - b);  // descending order  a-b ->ascending order for sort Numbers

 console.log(arr);

 //SORT Words without regards of the case used

 let arrWords = ['pepi', 'Gosho', 'Acho', 'Vanko', 'bobi'];

 arrWords.sort((a, b) => a.localeCompare(b));
 arrWords = arrWords.toString().toUpperCase()
 console.log(arrWords)

 //FOR EACH

 arr.forEach(n => console.log(n));  // below is the same 

 for (let num of arr){

    console.log(num)

 };

 //MAP  NonMutator

 let result = arr.map(x => x * 2);

 console.log(result);

 //Filter find by letter

 let arrTexts = ['pepi', 'Gosho', 'Acho', 'Vanko', 'bobi'];

let query = "a";

let answer = arrTexts.filter(x => {return x.toLowerCase().indexOf(query) >= 0;});

console.log(answer);



//Filter find by index position
function solve(input){

    return input 
        .filter((n, i) => i % 2 === 0);

};
 result = solve([1, 2, 3, 4, 5, 6, 7]);

 console.log(result)


 //REDUCE:

 let arr2 = [1, 2, 3, 4, 5, 6, 7];

result = arr2.reduce((total, current) => total + current);

console.log(result)