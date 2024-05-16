var RegisterTypes = {
    YKS: "YKS",
    DGS: "DGS",
    EK_MADDE: "Ek Madde-1",
    AGNO: "AGNO ile Merkezi Yatay Geçiş"
};

// Select elementini bul
var selectElement = document.getElementById('RegisterType');

// Enum verilerini select elementine ekle
for (var key in RegisterTypes) {
    var optionElement = document.createElement('option');
    optionElement.value = key;
    optionElement.textContent = RegisterTypes[key];
    selectElement.appendChild(optionElement);
}