<template>
  <b-container fluid>
    <b-row>
      <add-employee :onSave="() => {fetchEmployees()}"/>
    </b-row>
    <div>
      <b-table  
          responsive
          id="employee-table"
          small
          striped
          show-empty
          hover
          :items="employeesList"
          :fields="fields">
          
          <template v-slot:cell(Nr)="data">
              {{ data.index + 1 }}
          </template>
      </b-table>
    </div>
  </b-container>
</template>

<script>

import axios from 'axios';
import AddEmployee from '../components/AddEmployee.vue'
import Swal from "sweetalert2";

export default {
  name: 'EmployeeList',
  components: {
    AddEmployee
  },
  data() {
    return {
      employeesList: [],
      fields: [
        'Nr',
        'firstName',
        'lastName',
        'ssn',
        {
          key: 'phone',
          label: 'Telephone Number'
        }
      ]
    };
  },
  methods: {
    fetchEmployees() {
      axios.get('api/employees')
      .then(response => {
        this.employeesList = response.data
      })
      .catch(() => {
        Swal.fire({
            icon: "error",
            title: "Oooops....",
            text: "Something went wrong!"
          });
      })
    }
  },
  mounted: function() {
    this.fetchEmployees();
  }
}
</script>

<style scoped>
td {
  font-weight: bolder;
}
h3 {
  margin: 40px 0 0;
}
li {
  text-align: center;
}
</style>
