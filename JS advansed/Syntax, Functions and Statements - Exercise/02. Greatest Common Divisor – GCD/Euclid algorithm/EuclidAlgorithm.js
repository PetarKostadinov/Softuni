function solve(a, b){

    let small = Math.min(a, b);
    let big = Math.max(a, b);
    let reminder = 1;

    do{

        reminder = big % small;
        big = small;
        small = reminder;
        
    }while(reminder != 0);
   
    console.log(big);
}

solve(15, 5);
solve (2154, 458);