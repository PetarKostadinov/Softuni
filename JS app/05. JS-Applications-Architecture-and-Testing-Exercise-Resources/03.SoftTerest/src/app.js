

import { logout } from "./api/users.js";
import { initialize } from "./router.js";
import { showCatalog } from "./views/catalog.js";
import { showCreate } from "./views/create.js";
import { showDetails } from "./views/details.js";
import { showHome } from "./views/home.js";
import { showLogin } from "./views/login.js";
import { showRegister } from "./views/register.js";



const views = document.getElementById('views');
views.remove();



const links = {
    '/': showHome,
    '/register': showRegister,
    '/login': showLogin,
    '/details': showDetails,
    '/catalog': showCatalog,
    '/create': showCreate,
    '/logout': onLogout
}

const router = initialize(links)
router.updateNav();

//start application in home view 
router.goTo('/');

function onLogout(){
    logout();
    router.updateNav();
    router.goTo('/');
}




