<<<<<<< HEAD
// URL'den parametreleri almak iÃ§in
=======


// URL'den parametreleri almak için
>>>>>>> 493b85c33f660c8bff89bd658cca0ec887758dc7
const urlParams = new URLSearchParams(window.location.search);
//    id                    name
const name = urlParams.get('Name');
const surname = urlParams.get('Surname');
//const tcNo = urlParams.get('TcNo');
const studentNo = urlParams.get('StudentNo');
const mail = urlParams.get('MailAdress');
const telNo = urlParams.get('PhoneNo');
const register = urlParams.get('RegisterType');


<<<<<<< HEAD
// veya localStorage/sessionStorage'dan verileri almak iÃ§in
=======
// veya localStorage/sessionStorage'dan verileri almak için
>>>>>>> 493b85c33f660c8bff89bd658cca0ec887758dc7
// const name = localStorage.getItem('Name');
// const surname = localStorage.getItem('Surname');
// const studentNo = localStorage.getItem('StudentNo');
// const email = localStorage.getItem('MailAdress');

<<<<<<< HEAD
// HTML iÃ§ine alÄ±nan bilgileri yerleÅŸtirme
=======
// HTML içine alýnan bilgileri yerleþtirme
>>>>>>> 493b85c33f660c8bff89bd658cca0ec887758dc7
document.getElementById('nameSurname').innerText = `${name} ${surname}`;
//document.getElementById('tcNo').innerText = tcNo;
document.getElementById('studentNo').innerText = studentNo;
document.getElementById('email').innerText = mail;
document.getElementById('telNo').innerText = telNo;
document.getElementById('register').innerText = register;