window.addEventListener('DOMContentLoaded', () => {

    const register = document.getElementById('register');
    register.style.backgroundColor = '#6c8b47';
    const logout = document.getElementById('logout');
    logout.remove();
    const home = document.getElementById('home');
    home.style.backgroundColor = '#234465';

    document.querySelector('form#register button').addEventListener('click', async (e) => {
        e.preventDefault();

        const input = {
            email: () => document.querySelector('[name="email"]').value,
            password: () => document.querySelector('[name="password"]').value,
            rePass: () => document.querySelector('[name="rePass"]').value,
        }

        if (input.password() != input.rePass()) return;

        try {
            const res = await fetch('http://localhost:3030/users/register', {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ email: input.email(), password: input.password() })
            })

            if (res.ok != true) {
                const error = await res.json();
                throw new Error(error.message);
            }

            const data = await res.json();

            sessionStorage.setItem('userData', JSON.stringify(data))
            window.location = './index.html';

            let ddd = 4;
        } catch (error) {
            alert(error.message)
        }

    })
})