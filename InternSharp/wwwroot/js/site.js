// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Show the popup with JavaScript after successful login
function handleLoginSuccess() {
    const popup = document.getElementById("successPopup");
    if (popup) {
        popup.style.display = "flex";
    }
}

function goToHome() {
    window.location.href = "https://localhost:7252/";
    const signOutPopup = document.getElementById("SignOut");
    if (signOutPopup) {
        signOutPopup.style.display = "flex";
    }
}

// Simulate sign in
function signIn() {
    // Simulate successful login
    sessionStorage.setItem('isLoggedIn', 'true');
    updateAuthButton();

    // Optionally show popup
    handleLoginSuccess();
}

function signOut() {
    sessionStorage.removeItem('isLoggedIn');
    updateAuthButton();
}

function updateAuthButton() {
    const isLoggedIn = sessionStorage.getItem('isLoggedIn') === 'true';
    const authDiv = document.getElementById('authButton');

    if (!authDiv) {
        console.warn("Element with ID 'authButton' not found.");
        return;
    }

    if (isLoggedIn) {
        authDiv.innerHTML = `<button class="btn" onclick="signOut()">Sign Out</button>`;
    } else {
        authDiv.innerHTML = `<button class="btn" onclick="signIn()">Sign In</button>`;
    }
}

// Ensure DOM is fully loaded before running updateAuthButton
document.addEventListener("DOMContentLoaded", function () {
    updateAuthButton();
});
