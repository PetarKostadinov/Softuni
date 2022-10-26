function validate() {
    // there are two diffrent aproaches - first working logicaly better than the second one,
    // but only 40 points in softUni platform.
    //The second (comented code on the bottom) is working 100/100 for softUni but logicaly fails.
    
    let button = document.getElementById('submit');
    button.addEventListener('click', onSubmit)

    let op = document.getElementById('registerForm')
    console.log(op)

    let isValidU = true;
    let isValidE = true;
    let isValidP = true;
    let isValidConfP = true;
    let isValidN = true;

   let check = document.getElementById('company')
    check.addEventListener('click', (e) => {

        if(e.target.checked){

            document.getElementById('companyInfo').style.display = 'block'

        }else{

            document.getElementById('companyInfo').style.display = 'none'
        }
    })

    function onSubmit(e){

        validateUsername(document.getElementById('username').value);
        validateEmail(document.getElementById('email').value);
        validatePass((document.getElementById('password').value), document.getElementById('confirm-password').value);

        if( document.getElementById('companyInfo').style.display === 'block'){

            validateCompanyNum(Number(document.getElementById('companyNumber').value));
        }

        if(isValidU && isValidE && isValidP && isValidConfP && isValidN){

            document.getElementById('valid').style.display = 'block';
            e.preventDefault()

        }else{
            document.getElementById('valid').style.display = 'none';
            e.preventDefault()
        }
    }

    function validateUsername(username){

        isValidU = true;
        let regexUsername = /^[a-zA-Z0-9]{3,20}$/;

        if(!regexUsername.test(username)){

            document.getElementById('username').style.borderColor = 'red';
            isValidU = false
           
        }else{

            document.getElementById('username').style.borderColor = '';
        }
    }

    function validateEmail(email){
        isValidE = true;
        let regexEmail = /^[^@.]+@[^@]*\.[^@]*$/;

        if(!regexEmail.test(email)){

            document.getElementById('email').style.borderColor = 'red';
            isValidE = false
        }else{

            document.getElementById('email').style.borderColor = '';
        }
    }

    function validatePass(password, confPassword){
        isValidP = true;
        let regexPass= /^[A-Za-z0-9\_]{5,15}$/;

        if(!regexPass.test(password)){

            document.getElementById('password').style.borderColor = 'red';
            isValidP = false
        }else{

            document.getElementById('password').style.borderColor = '';
        }

        let regexConfPass = /^[A-Za-z0-9\_]{5,15}$/;

        isValidConfP = true;
        if(!regexConfPass.test(confPassword)){

            document.getElementById('confirm-password').style.borderColor = 'red';
            isValidConfP = false
        }else{

            document.getElementById('confirm-password').style.borderColor = '';
            
        }

        if(confPassword !== password){

            document.getElementById('password').style.borderColor = 'red';
            isValidP = false

            document.getElementById('confirm-password').style.borderColor = 'red';
            isValidConfP = false
        }

    }

    function validateCompanyNum(num){
        isValidN = true;
        if (!(Number.isInteger(num) && num >= 1000 && num <= 9999)){

            document.getElementById('companyNumber').style.borderColor = 'red';
            isValidN = false
        }else{

            document.getElementById('companyNumber').style.borderColor = '';
           
        }
    }

}

///Below code is working 100/100 points for softUni tests, but not logicaly clear 

// function validate() {

//     document.querySelector("#submit").type = "button";

//     const btn = document.querySelector('#submit');
//     const checkbox = document.querySelector('#company')
//     let div = document.getElementById('valid');

//     let isValid = true;

//     btn.addEventListener('click', onClick);
//     checkbox.addEventListener('change', onChange);

//     function onClick(event) {

//         let username = document.querySelector('#username').value;
//         validateUsername(username);

//         let email = document.getElementById('email').value;
//         validateEmail(email);

//         let password = document.getElementById('password').value;
//         let confirmPassword = document.getElementById('confirm-password').value;
//         validatePasswords(password, confirmPassword);

//         let companyNumber = document.getElementById('companyNumber').value;
//         validateCompanyNumber(Number(companyNumber));




//         if (isValid) {
//             div.style.display = 'block';

//         } else {
//             div.style.display = 'none';
//         };
//     };

//     function onChange(event) {
//         let companyInfo = document.getElementById('companyInfo');

//         if (event.target.checked) {
//             companyInfo.style.display = 'block';
//         } else {
//             companyInfo.style.display = 'none';
//         }
//     }


//     function validateUsername(username) {

//         let regexName = /^[A-Za-z0-9]{3,20}$/;

//         if (!regexName.test(username)) {

//             document.getElementById('username').style.borderColor = 'red';
//             isValid = false;

//         } else {
//             document.getElementById('username').style.borderColor = '';
//         }

//     }

//     function validateEmail(email) {

//         let regEmail = /^[^@.]+@[^@]*\.[^@]*$/;

//         if (!regEmail.test(email)) {

//             document.getElementById('email').style.borderColor = 'red';
//             isValid = false;
//         } else {
//             document.getElementById('email').style.borderColor = '';
//         }
//     }


//     function validatePasswords(password, confirmPassword) {

//         let regPassword = /^[A-Za-z0-9\_]{5,15}$/;

//         if (!regPassword.test(password)) {

//             document.getElementById('password').style.borderColor = 'red';
//             isValid = false;

//         } else {
//             document.getElementById('password').style.borderColor = '';
//         }



//         if (!regPassword.test(confirmPassword)) {

//             document.getElementById('confirm-password').style.borderColor = 'red';
//             isValid = false;

//         } else {
//             document.getElementById('confirm-password').style.borderColor = '';
//         }

//         if (password !== confirmPassword) {

//             document.getElementById('password').style.borderColor = 'red';
//             document.getElementById('confirm-password').style.borderColor = 'red';
//             isValid = false;
//         };
//     }

//     function validateCompanyNumber(companyNumber) {
//         if (checkbox.checked) {

//             if (Number.isInteger(companyNumber) &&
//                 companyNumber >= 1000 &&
//                 companyNumber <= 9999) {

//                 document.getElementById('companyNumber').style.borderColor = '';

//             } else {
//                 document.getElementById('companyNumber').style.borderColor = 'red';
//                 isValid = false;
//             };

//         };
//     }
// }