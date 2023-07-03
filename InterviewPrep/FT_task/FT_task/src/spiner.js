export function showSpiner() {
    const appElement = document.getElementById('app');
    appElement.innerHTML = '';
    const spinner = document.createElement('div');
    const loadingMessage = document.createElement('div');
    loadingMessage.textContent = 'Please Wait, Loading Markets Data ...';
    spinner.classList.add('spinner');
    appElement.appendChild(spinner);
    appElement.appendChild(loadingMessage);
};