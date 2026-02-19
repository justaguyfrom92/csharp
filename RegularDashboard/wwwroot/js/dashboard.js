const connection = new signalR.HubConnectionBuilder()
    .withUrl('/dashboardHub')
    .withAutomaticReconnect()
    .build();

const connDot     = document.getElementById('connDot');
const collapsible = document.getElementById('collapsible');
const btnLabel    = document.getElementById('btnLabel');
const statusBar   = document.getElementById('statusBar');

// ── Receive state broadcast from server ──────────────────────────────────────
connection.on('ReceiveSectionState', (visible) => {
    if (visible) {
        collapsible.classList.remove('hidden');
        btnLabel.textContent = 'Hide Section';
    } else {
        collapsible.classList.add('hidden');
        btnLabel.textContent = 'Show Section';
    }
    statusBar.textContent = `Section ${visible ? 'shown' : 'hidden'} — synced via SignalR`;
});

connection.onreconnecting(() => {
    connDot.classList.remove('connected');
    statusBar.textContent = 'Reconnecting…';
});

connection.onreconnected(() => {
    connDot.classList.add('connected');
    statusBar.textContent = 'Reconnected ✓';
});

connection.onclose(() => {
    connDot.classList.remove('connected');
    statusBar.textContent = 'Disconnected';
});

// ── Start connection ─────────────────────────────────────────────────────────
async function startConnection() {
    try {
        await connection.start();
        connDot.classList.add('connected');
        statusBar.textContent = 'Connected via SignalR ✓';
    } catch (err) {
        statusBar.textContent = 'Connection failed — retrying…';
        setTimeout(startConnection, 3000);
    }
}

startConnection();

// ── Toggle invoked from the button ───────────────────────────────────────────
async function toggle() {
    if (connection.state === signalR.HubConnectionState.Connected) {
        await connection.invoke('ToggleSection');
    }
}
