
export function initialize(links) {

    const main = document.querySelector('main');
    let nav = document.querySelector('nav');
    nav.addEventListener('click', onNav);

    const context = {
        showSection,
        goTo,
        updateNav
    }

    return context;

    function showSection(section) {

        main.replaceChildren(section)
    }

    function onNav(ev) {
        let target = ev.target;
        if (target.tagName == 'IMG') {
            target = target.parentElement;
        }

        if (target.tagName == 'A') {
            ev.preventDefault();
            const url = new URL(target.href);
            goTo(url.pathname)
        }
    }

    function goTo(name, ...params) {

        const hendler = links[name];
        if (typeof hendler == 'function') {
            hendler(context, ...params)
        }
    }

    function updateNav() {
        const user = localStorage.getItem('user');
        if (user) {

            nav.querySelectorAll('.user').forEach(x => x.style.display = 'block');
            nav.querySelectorAll('.guest').forEach(x => x.style.display = 'none');

        } else {

            nav.querySelectorAll('.user').forEach(x => x.style.display = 'none');
            nav.querySelectorAll('.guest').forEach(x => x.style.display = 'block');

        }
    }
}

// //below for test in console ONLY!!!

// window.showHome = () => {
//     showHome(context);
// }