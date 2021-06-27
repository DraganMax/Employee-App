<template>
    <div>
    <b-button variant="primary" @click="onReset" v-b-modal.add-modal class="mt-0 mb-3" size="sm">Add Employee <b-icon icon="person-plus-fill" /></b-button>

    <b-modal id="add-modal" size="lg" hide-footer @shown="focusElement" title="Adding Employee">
      <div>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
          <b-row>
            <b-col>
              <b-form-group id="input-group-1" label-for="input-1">
                <template>
                  First Name<span class="text-danger">*</span>
                </template>
                <b-form-input
                  id="input-1"
                  ref="focusThis"
                  v-model="form.firstName"
                  required
                  placeholder="First Name"
                ></b-form-input>
              </b-form-group>
            </b-col>
            <b-col>
              <b-form-group id="input-group-2" label-for="input-2">
                <template>
                  Last Name<span class="text-danger">*</span>
                </template>
                <b-form-input
                  id="input-2"
                  v-model="form.lastName"
                  required
                  placeholder="Last Name"
                  class="required"
                ></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>

          <b-row>
            <b-col>
              <b-form-group id="input-group-3" label-for="input-3">
                <template>
                  SSN<span class="text-danger">*</span>
                </template>
                <b-form-input id="input-3" type="text" v-mask="'###-##'" v-model="form.ssn" required placeholder="Social Security Number">
                </b-form-input>
                <b-form-text id="ssn-help-block">
                  Ssn consists of numbers
                </b-form-text>
              </b-form-group>
            </b-col>

            <b-col>
              <b-form-group id="input-group-5" label-for="input-5">
                <template>
                  Phone Number
                </template>
                <b-form-input
                  class="mb-0"
                  type="tel"
                  v-mask="'##-###-##'"
                  pattern="^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$"
                  id="input-5"
                  v-model="form.phone"
                  placeholder="Phone number"
                ></b-form-input>
                <b-form-text id="ssn-help-block">
                  Phone number consists of numbers
                </b-form-text>
              </b-form-group>
            </b-col>
          </b-row>
          <b-button class="formBtn" size="sm" @click="$bvModal.hide('add-modal')">Cancel</b-button>
          <b-button class="formBtn" size="sm" type="reset" variant="warning">Reset</b-button>
          <b-button class="formBtn submit"  size="sm" type="submit" variant="primary">Submit</b-button>
        </b-form>
      </div>
    </b-modal>
  </div>
</template>

<script>
import axios from 'axios';
import Swal from "sweetalert2";

export default {

  props: {  
    onSave: Function
  },
  data() {
    return {
      form: {
        firstName: "",
        lastName: "",
        ssn: "",
        phone: "",
      },
      show: true
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();

      axios
        .post("api/employee", {
          firstName: this.form.firstName,
          lastName: this.form.lastName,
          ssn: this.form.ssn,
          phone: this.form.phone,
        })
        .then(response => {
          if (response.status === 200 || response.status === 201) {
            Swal.fire("Good job!", "You added a employee!", "success");
          }
          if (this.onSave) {
            this.onSave();
          }
        })
        .catch(error => {
          Swal.fire({
            icon: "error",
            title: "Oooops....",
            text: error ? error.response.data.message : "Something went wrong!"
          });
        })
        .then(() => {
          this.$bvModal.hide('add-modal');
        });
    },
    onReset(evt) {
      evt.preventDefault();

      this.form.firstName = "";
      this.form.lastName = "";
      this.form.ssn = "";
      this.form.phone = "";

      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
    focusElement() {
      this.$refs.focusThis.focus();
    },
  }
}
</script>

<style scoped>
.row {
  margin-top: 10px;
}
.formBtn {
  margin-top: 10px;
  margin-right: 10px;
}
.required:after {
  content: "*";
  color: red;
}
input {
  color: black;
}
.submit {
  float: right;
}
</style>
