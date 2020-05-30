<template>
  <div>
    <div class="jumbotron jumbotron-sm background-fix border">
      <div class="container">
        <div class="row">
          <div class="col-sm-12 col-lg-12">
            <h1 class="h1">Please select class and subject</h1>
          </div>
        </div>
      </div>
    </div>
    <el-card>
      <el-form
        :inline="true"
        ref="ruleForm"
        :model="formModel"
        :rules="rules"
        class="demo-form-inline"
        size="medium"
      >
        <el-form-item label="Select Class:" prop="classSelection">
          <el-select v-model="formModel.classSelected" placeholder="Select class">
            <el-option
              v-for="item in classes"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="Select Subject" prop="subjectSelection">
          <el-select v-model="formModel.subjectSelection" placeholder="Select subject">
            <el-option
              v-for="item in subjects"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm('ruleForm')">Submit</el-button>
          <el-button @click="resetForm('ruleForm')">Reset</el-button>
        </el-form-item>
      </el-form>
    </el-card>
    <section class="mb-5">
      <div class="container">
        <div class="row title py-3">
          <div class="col-md-12">
            <h5>
              <strong>Video Lectures</strong>
            </h5>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <div class="row mb-3">
              <div class="col-md-12">
                <div class="card">
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-3">
                        <img src="../assets/video-thumbnail.png" />
                      </div>
                      <div class="col-md-7">
                        <h5>Msexchange contributes senior UX Designer</h5>
                        <small>Jopitor Inc., India</small>
                        <p>
                          <small>11907 Dyuuleves Incorpotatestion, South west, Newzealer</small>
                        </p>
                      </div>
                      <div class="col-md-2">
                        <button type="button" class="btn btn-outline bg-orange">Get Quotes</button>
                        <small>Published on Nov 27, 2017</small>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-3">
              <div class="col-md-12">
                <div class="card">
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-3">
                        <img src="../assets/video-thumbnail.png" />
                      </div>
                      <div class="col-md-7">
                        <h5>Msexchange contributes senior UX Designer</h5>
                        <small>Jopitor Inc., India</small>
                        <p>
                          <small>11907 Dyuuleves Incorpotatestion, South west, Newzealer</small>
                        </p>
                      </div>
                      <div class="col-md-2">
                        <button type="button" class="btn btn-outline bg-orange">Get Quotes</button>
                        <small>Published on Nov 27, 2017</small>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row mb-3">
              <div class="col-md-12">
                <div class="card">
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-3">
                        <img src="../assets/video-thumbnail.png" />
                      </div>
                      <div class="col-md-7">
                        <h5>Msexchange contributes senior UX Designer</h5>
                        <small>Jopitor Inc., India</small>
                        <p>
                          <small>11907 Dyuuleves Incorpotatestion, South west, Newzealer</small>
                        </p>
                      </div>
                      <div class="col-md-2">
                        <button type="button" class="btn btn-outline bg-orange">Get Quotes</button>
                        <small>Published on Nov 27, 2017</small>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: "listing",
  data() {
    return {
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
        classSelected: "",
        subjectsSelected: ""
      },
      rules: {
        classSelection: [
          { required: true, message: "Please select class!", trigger: "change" }
        ],
        subjectSelection: [
          {
            required: true,
            message: "Please select subject!",
            trigger: "change"
          }
        ]
      }
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          alert("submit!");
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    }
  }
};
</script>

<style scoped>
.bg-orange {
  background: #d8622b;
  color: #fff !important;
}
img {
  width: 100%;
  max-height: 560px;
}
a {
  color: #696969;
}
.background-fix {
  background: linear-gradient(45deg, #54d400 56%, #1b1e21 100%);
  color: #fff;
}
</style>
