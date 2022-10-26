function notify(message) {
  
  let notification = document.getElementById('notification')
  notification.innerText = message
  notification.style.display = 'block';

  notification.addEventListener('click', onTogle)
  
  function onTogle(e){

    e.target.style.display = 'none';
  }
  
}

