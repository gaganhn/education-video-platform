import Axios from 'axios';

export default {
  name: "listing",
  data() {
    return {
      metaData: null,
      formModel: {
        classSelected: '',
        subjectSelected: '',
      },
    };
  },
  created() {
    Axios.get('http://localhost:5000/metadata')
    .then(metaData => {
      this.metaData = metaData.data.standards;
    })
  },
  computed: {
    classSelected: function () {
      return this.metaData && this.formModel.classSelected !== '' ?
        this.metaData[this.formModel.classSelected] :
        {};
    },
    subjectSelected: function () {
      return this.metaData && this.formModel.subjectSelected !== '' && this.formModel.classSelected !== '' ?
        this.metaData[this.formModel.classSelected].subjects[this.formModel.subjectSelected] :
        {};
    },
  },
  methods: {}
};