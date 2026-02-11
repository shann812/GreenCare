import { loadHeader, updateAuthHeader} from '../shared/header.js';
import { initLoginModal } from '../shared/loginModal.js';

await loadHeader();
updateAuthHeader();
initLoginModal();