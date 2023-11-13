
import { createApp } from 'vue'
import App from './App.vue'
import ReportViewer from './components/ReportViewer.vue';

createApp(App).component('report-viewer', ReportViewer).mount('#app');
