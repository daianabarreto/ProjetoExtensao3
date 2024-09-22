import { initializeApp } from "firebase/app";
import { getStorage } from "firebase/storage";
import { getFirestore } from "firebase/firestore";
// Configuração do Firebase
const firebaseConfig = {
    apiKey: "AIzaSyAf6l_oPdN0ZxR0L03XvhtzwQvqpj7F6mM",
    authDomain: "controle-enchentes.firebaseapp.com",
    databaseURL: "https://controle-enchentes-default-rtdb.firebaseio.com",
    projectId: "controle-enchentes",
    storageBucket: "controle-enchentes.appspot.com",
    messagingSenderId: "78343132048",
    appId: "1:78343132048:web:a06f3a2e7673a6d6fe1915"
};

// Inicializar Firebase
const defaultProject = firebase.initializeApp(firebaseConfig);
console.log(defaultProject.name);  // "[DEFAULT]"
const database = firebase.database();
