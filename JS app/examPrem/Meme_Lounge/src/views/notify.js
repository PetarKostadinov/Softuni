const notifications = document.getElementById('errorBox');
const span = document.querySelector('span');


export function showNotification(message) {

    span.textContent = message;
    notifications.style.display = 'block';

    setTimeout(() => notifications.style.display = 'none', 3000);
}