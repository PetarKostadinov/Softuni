function ex1 (arr) {

   const result = {};

   for (let i = 0; i < arr.length; i+=2){

        result[arr[i]] = Number(arr[i + 1])
   }

   console.log(result)

}

ex1(['Yoghurt', '48', 'Rise', '138','Apple', '52'])