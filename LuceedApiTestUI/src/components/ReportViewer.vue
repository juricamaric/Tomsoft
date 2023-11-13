<template>
  <div id="report-viewer">

    <!-- Artikli - pretraživanje -->
    <div class="method-container">
      <label>Artikli pretraživanje:</label>
      <input v-model="articleSearch" />
      <button @click="fetchArticles" :disabled="!articleSearch">Dohvati artikle</button>
    </div>

    <!-- Artikli Placeholder -->
    <div v-if="articles.length > 0" class="results-placeholder">
      <h2>Artikli</h2>
      <ul>
        <li v-for="article in articles" :key="article.id">{{ article.naziv }}</li>
      </ul>
    </div>
    <div v-else class="no-data-message">No data available</div>

    <!-- Obračun plaćanja -->
    <div class="method-container">
      <label>PjUid:</label>
      <input v-model="pjUid" :disabled="true" />
      <label>Od datuma:</label>
      <input type="date" v-model="report1OdDatuma" />
      <label>Do datuma:</label>
      <input type="date" v-model="report1DoDatuma" />
      <button @click="fetchReport1" :disabled="!report1OdDatuma || !report1DoDatuma">Dohvati obračun plaćanja</button>
    </div>

    <!-- Obračun plaćanja Placeholder -->
    <div v-if="report1Data && report1Data.length > 0" class="results-placeholder">
      <h2>Obračun plaćanja</h2>
      <table>
        <thead>
          <tr>
            <th>Vrste Placanja UID</th>
            <th>Naziv</th>
            <th>Iznos</th>
            <th>Nadgrupa Placanja UID</th>
            <th>Nadgrupa Placanja Naziv</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in report1Data" :key="item.vrstePlacanjaUid">
            <td>{{ item.vrstePlacanjaUid }}</td>
            <td>{{ item.naziv }}</td>
            <td>{{ item.iznos }}</td>
            <td>{{ item.nadgrupaPlacanjaUid }}</td>
            <td>{{ item.nadgrupaPlacanjaNaziv }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-else class="no-data-message">No data available</div>

    <!-- Report 2 -->
    <div class="method-container">
      <label>PjUid:</label>
      <input v-model="pjUid" :disabled="true" />
      <label>Od datuma:</label>
      <input type="date" v-model="report2OdDatuma" />
      <label>Do datuma:</label>
      <input type="date" v-model="report2DoDatuma" />
      <button @click="fetchReport2" :disabled="!report2OdDatuma || !report2DoDatuma">Dohvati obračun artikala</button>
    </div>

    <!-- Obračun artikli Placeholder -->
    <div v-if="report2Data && report2Data.length > 0" class="results-placeholder">
      <h2>Obračun artikli</h2>
      <table>
        <thead>
          <tr>
            <th>Artikl UID</th>
            <th>Naziv Artikla</th>
            <th>Kolicina</th>
            <th>Iznos</th>
            <th>Usluga</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in report2Data" :key="item.artiklUid">
            <td>{{ item.artiklUid }}</td>
            <td>{{ item.nazivArtikla }}</td>
            <td>{{ item.kolicina }}</td>
            <td>{{ item.iznos }}</td>
            <td>{{ item.usluga }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-else class="no-data-message">No data available</div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      articleSearch: '',
      articles: [],
      pjUid: '4986-1',
      report1OdDatuma: '2010-01-01',
      report1DoDatuma: '',
      report2OdDatuma: '2010-01-01',
      report2DoDatuma: '',
      report1Data: null,
      report2Data: null,
    };
  },
  methods: {
    async fetchArticles() {
      try {
        const response = await axios.get(`http://localhost:5009/api/article?namePart=${this.articleSearch}`);
        this.articles = response.data;
      } catch (error) {
        console.error('Error fetching articles:', error);
      }
    },
    async fetchReport1() {
      try {
        const response = await axios.get(`http://localhost:5009/api/Obracun/placanja?pjUid=${this.pjUid}&odDatuma=${this.report1OdDatuma}&doDatuma=${this.report1DoDatuma}`);
        this.report1Data = response.data;
      } catch (error) {
        console.error('Error fetching Report 1 data:', error);
      }
    },
    async fetchReport2() {
      try {
        const response = await axios.get(`http://localhost:5009/api/Obracun/artikli?pjUid=${this.pjUid}&odDatuma=${this.report2OdDatuma}&doDatuma=${this.report2DoDatuma}`);
        this.report2Data = response.data;
      } catch (error) {
        console.error('Error fetching Report 2 data:', error);
      }
    },
  },
};
</script>

<style scoped>
#report-viewer {
  max-width: 1200px;
  margin: 0 auto;
}

.method-container {
  margin-bottom: 20px;
}

button {
  font-size: 1em;
  margin: 0 10px;
  padding: 10px;
  cursor: pointer;
}

.results-placeholder {
  margin-top: 50px;
  margin-bottom: 50px;
}

.no-data-message {
  margin-top: 20px;
  color: #666;
  font-style: italic;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 10px;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}

th {
  background-color: #f2f2f2;
}

h2 {
  font-size: 1.5em;
}
</style>