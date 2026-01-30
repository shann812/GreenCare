export async function loadHeader() {
    const response = await fetch('/src/assets/components/header.html');
    const html = await response.text();

    document.getElementById('header-placeholder').innerHTML = html;
}

export function updateAuthHeader() {
    const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';

    const notAuth = document.getElementById('not-auth');
    const auth = document.getElementById('auth');

    if(!notAuth || !auth)
        return;

    if(isLoggedIn){
        notAuth.style.display = 'none';
        auth.style.display = 'flex';
        document.getElementById('userNameDisplay').textContent = localStorage.getItem('userName') ?? 'Guest';
    } else{
        notAuth.style.display = 'flex';
        auth.style.display = 'none';
    }
}