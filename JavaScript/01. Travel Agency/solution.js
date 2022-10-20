window.addEventListener('load', solution);

function solution() {

  const obj = {

    fname: document.getElementById('fname'),
    email: document.getElementById('email'),
    phone: document.getElementById('phone'),
    address: document.getElementById('address'),
    code: document.getElementById('code')
  }

  let submitBtn = document.getElementById('submitBTN');
  submitBtn.addEventListener('click', onSubmit);

  function onSubmit(ev) {

    let fname = obj.fname.value;
    let email = obj.email.value;
    let phone = obj.phone.value;
    let address = obj.address.value;
    let code = obj.code.value;

    if (fname == '' || email == '') {
      return;
    }

    let liFname = document.createElement('li');
    liFname.textContent = `Full Name: ${fname}`;
    let liEmail = document.createElement('li');
    liEmail.textContent = `Email: ${email}`;
    let liPhone = document.createElement('li');
    liPhone.textContent = `Phone Number: ${phone}`;
    let liAddress = document.createElement('li');
    liAddress.textContent = `Address: ${address}`;
    let liCode = document.createElement('li');
    liCode.textContent = `Postal Code: ${code}`;

    let ul = document.getElementById('infoPreview');
    ul.appendChild(liFname);
    ul.appendChild(liEmail);
    ul.appendChild(liPhone);
    ul.appendChild(liAddress);
    ul.appendChild(liCode);

    obj.fname.value = '';
    obj.email.value = '';
    obj.phone.value = '';
    obj.address.value = '';
    obj.code.value = '';

    ev.target.disabled = true;

    let editBtn = document.getElementById('editBTN');
    let continueBtn = document.getElementById('continueBTN');
    editBtn.disabled = false;
    continueBtn.disabled = false;

    editBtn.addEventListener('click', onEdit)

    function onEdit(ev){

      liFname.remove()
      liEmail.remove()
      liPhone.remove()
      liAddress.remove()
      liCode.remove()

      obj.fname.value = fname;
      obj.email.value = email;
      obj.phone.value = phone;
      obj.address.value = address;
      obj.code.value = code;
      editBtn.disabled = true;
      continueBtn.disabled = true;
      submitBtn.disabled = false;

    }

    continueBtn.addEventListener('click', onContinue);

    function onContinue(ev){

      let block = document.getElementById('block');
      block.innerHTML = '';

      // let blockArr = Array.from(document.getElementById('block').children)
      // blockArr.forEach(x => x.remove())
      
      let h3 = document.createElement('h3');
      h3.textContent = `Thank you for your reservation!`;
      block.appendChild(h3);

    }
  }
}
