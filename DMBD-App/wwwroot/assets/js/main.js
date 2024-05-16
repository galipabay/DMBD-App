// URL'den parametreleri almak için
const urlParams = new URLSearchParams(window.location.search);
//    id                    name
const name = urlParams.get('Name');
const surname = urlParams.get('Surname');
//const tcNo = urlParams.get('TcNo');
const studentNo = urlParams.get('StudentNo');
const mail = urlParams.get('MailAdress');
const telNo = urlParams.get('PhoneNo');
const register = urlParams.get('RegisterType');


// veya localStorage/sessionStorage'dan verileri almak için
// const name = localStorage.getItem('Name');
// const surname = localStorage.getItem('Surname');
// const studentNo = localStorage.getItem('StudentNo');
// const email = localStorage.getItem('MailAdress');

// HTML içine alınan bilgileri yerleştirme
document.getElementById('nameSurname').innerText = `${name} ${surname}`;
//document.getElementById('tcNo').innerText = tcNo;
document.getElementById('studentNo').innerText = studentNo;
document.getElementById('email').innerText = mail;
document.getElementById('telNo').innerText = telNo;
document.getElementById('register').innerText = register;