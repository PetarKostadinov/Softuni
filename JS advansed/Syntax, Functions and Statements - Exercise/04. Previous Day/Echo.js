function solve(x, y, z) {
 
  let s = new Date(x, y, z)

  var d = s
  d.setDate(d.getDate() - 1);
  
  let a = d.getFullYear()
  let b = d.getMonth()
  let c = d.getDate()

  if (c =='31'){

    c = new Date(a, b, 0).getDate();
  }


  return `${a}-${b}-${c}`;
}


console.log(solve(2016, 9, 30))
console.log(solve(2016, 10, 1))
console.log(solve(2019, 3, 1))
