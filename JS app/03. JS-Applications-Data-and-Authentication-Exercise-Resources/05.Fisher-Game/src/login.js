window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', onLogin);

    const upperLogin = document.getElementById('login');
    upperLogin.style.backgroundColor = '#6c8b47';

    const logout = document.getElementById('logout');
    logout.remove();
    const home = document.getElementById('home');
    home.style.backgroundColor = '#234465';

})

async function onLogin(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);
    
    const email = formData.get('email');
    const password = formData.get('password');
    try {

        const res = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({email, password})
        })

        if (res.ok != true) {
            const error = await res.json();
            throw new Error(error.message); 
        }

        const data = await res.json();
        const userData = {
            email: data.email,
            id: data._id,
            token: data.accessToken
        }
        sessionStorage.setItem('userData', JSON.stringify(userData))
        window.location = './index.html';

    } catch (error) {
        alert(error.message)
    }



}


// const form = document.querySelector('form');
// let userView = document.getElementById('user');
// let guestView = document.getElementById('guest');

// userView.style.display = 'none';
// guestView.style.display = 'inline-block';

// form.addEventListener('submit', loginUser)

// async function loginUser(event) {
//     event.preventDefault();

//     const formData = new FormData(event.target);

//     let email = formData.get('email');
//     let password = formData.get('password');

//     if (email == '' && password == '') {
//         alert('Please fill the required fields!');
//         return;
//     } else if (email == '') {
//         alert('Please enter your email address!');
//         return;
//     } else if (password == '') {
//         alert('Please enter your password!');
//         return;
//     }

//     try {
//         const response = await fetch('http://localhost:3030/users/login', {
//             method: 'POST',
//             headers: { 'Content-type': 'aplication/json' },
//             body: JSON.stringify({ email, password })
//         });
//         const data = await response.json();

//         if (!response.ok || response.status != 200) {
//             form.reset();
//             throw new Error(data.message);
//         }
        
//         sessionStorage.setItem('userEmail', data.email);
//         sessionStorage.setItem('authToken', data.accessToken);
//         sessionStorage.setItem('userId', data._id);
//         window.location.href = './index.html';

//     } catch (error) {
//         alert(error.message);
//     }
// }