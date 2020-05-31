import Axios from 'axios';

export default {
  name: "listing",
  data() {
    return {
      metaData: null,
      classes: [
        {
          value: "1",
          label: "Class 1"
        },
        {
          value: "2",
          label: "Class 2"
        },
        {
          value: "3",
          label: "Class 3"
        },
        {
          value: "4",
          label: "Class 4"
        },
        {
          value: "5",
          label: "Class 5"
        },
        {
          value: "6",
          label: "Class 6"
        },
        {
          value: "7",
          label: "Class 7"
        },
        {
          value: "8",
          label: "Class 8"
        },
        {
          value: "9",
          label: "Class 9"
        },
        {
          value: "10",
          label: "Class 10"
        }
      ],
      subjects: [
        {
          value: "1",
          label: "English"
        },
        {
          value: "2",
          label: "Kannada"
        },
        {
          value: "3",
          label: "Hindi"
        },
        {
          value: "4",
          label: "Social Studies"
        },
        {
          value: "5",
          label: "Science"
        },
        {
          value: "6",
          label: "Mathematics"
        }
      ],
      formModel: {
        classSelected: '',
        subjectsSelected: '',
      },
    };
  },
  created() {
    Axios.get('http://localhost:5000/metadata')
    .then(metaData => {
      this.metaData = metaData.data.standards;
    })
  },
  methods: {
    formatMetaDataObj() {
      this.metaData = Object.values(this.metaData);
      for (let i = 0; i < this.metaData.length; i++) {
        let subjects = Object.values(this.metaData[i].subjects);
        for (let j = 0; j < subjects.length; j++) {
          subjects[j].lectures = Object.values(subjects[j].lectures);
        }
        this.metaData[i].subjects = subjects;
      }
      console.log('this.metaData', this.metaData);
    },
    submitForm() {
      if (this.formModel.classSelected == '' || this.formModel.subjectsSelected == '') {
        this.inValid = true;
      }
      console.log(this.formModel.classSelected);
      console.log(this.formModel.subjectsSelected);
    },
    clear() {
      this.formModel.classSelected = '';
      this.formModel.subjectsSelected = '';
    }
  }
};