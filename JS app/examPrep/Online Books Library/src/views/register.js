import { register } from "../api/users.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";



const registerTemplate = (onRegister) => html`
<section id="register-page" class="register">
    <form @submit=${onRegister} id="register-form" action="" method="post">
        <fieldset>
            <legend>Register Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>`;

export async function showRegister(ctx) {

    ctx.render(registerTemplate(createSubmitHandler(onRegister)));



    async function onRegister(data) {

        if (data.email == '' || data.password == '') {
            return alert('All fields are required!')
        }

        if (data.password != data["confirm-pass"]) {
            return alert('Passwords don\'t match!')
        }

        await register(data.email, data.password);
        ctx.updateNav();
        ctx.page.redirect('/');

    }
}