// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Show the popup with JavaScript after successful login
function signIn() {
    // Simulate successful login logic
    // Normally you'd check username/password via backend here
    const isLoginSuccessful = true; // Simulate login success

    if (isLoginSuccessful) {
        sessionStorage.setItem('isLoggedIn', 'true');

        // Show popup
        document.getElementById("successPopup").style.display = "flex";
    } else {
        alert("Invalid credentials");
    }
}
function handleLoginSuccess() {
    // Show the popup
    document.getElementById("successPopup").style.display = "flex";
}
function goToHome() {
    window.location.href = "https://localhost:7252/"; // or your home.cshtml
    // Show the popup
    document.getElementById("SignOut").style.display = "flex";
    

}

// Simulate sign in
function signIn() {
    // Perform login logic or redirect...
    // Simulate success
    //window.location.href = "https://localhost:7252/Accounts/SignIn"; // or your home.cshtml
    sessionStorage.setItem('isLoggedIn', 'true');
    updateAuthButton();
}

function signOut() {
    sessionStorage.removeItem('isLoggedIn');
    updateAuthButton();
}

function updateAuthButton() {
    const isLoggedIn = sessionStorage.getItem('isLoggedIn') === 'true';
    const authDiv = document.getElementById('authButton');
    if (isLoggedIn) {
        authDiv.innerHTML = `<button class="btn" onclick="signOut()">Sign Out</button>`;
    } else {
        authDiv.innerHTML = `<button class="btn" onclick="signIn()">Sign In</button>`;
    }
}

// Call on page load
updateAuthButton();

