export default {
  name: "video-player",
  data() {
    return {
      socketConnection: null,
      mediaSource: null,
      sourceBuffer: null,
      chunksCount: 0,
      videoURL: '',
    };
  },
  mounted() {
    this.videoURL = this.$route.params.standard + '/' + this.$route.params.subject + '/' + this.$route.params.lecture;
    this.init();
  },
  methods: {
    init() {
      let self = this;
      var video = this.$refs["lecture_video"];
      if (!window.MediaSource) {
        console.log('The MediaSource API is not available on this platform');
      }
      this.mediaSource = new MediaSource();
      video.src = window.URL.createObjectURL(this.mediaSource);
      this.initWebSocketConnection();
      this.mediaSource.addEventListener('sourceopen', function () {
        self.sourceBuffer = self.mediaSource.addSourceBuffer('video/webm;codecs="vp8,vorbis"');
        console.log('MediaSource readyState: ' + this.readyState);
      }, false);

      this.mediaSource.addEventListener('sourceended', function () {
        console.log('MediaSource readyState: ' + this.readyState);
      }, false);
    },
    initWebSocketConnection() {

      console.log("Connecting to the websocket server...")

      this.socketConnection = new WebSocket("ws://localhost:5000/video/" + this.videoURL);
      this.socketConnection.binaryType = 'arraybuffer';

      this.socketConnection.onmessage = (event) => {
        let videoChuck_ = new Uint8Array(event.data);
        this.readChunk(this.chunksCount, videoChuck_);
        ++this.chunksCount;
      };

      this.socketConnection.onopen = function (event) {
        console.log(event)
        console.log("Successfully connected to the websocket server...")
      }

      this.socketConnection.onclose = function () {
        console.log("WebSocket is closed now.");
        this.sourceBuffer.addEventListener('updateend', function () {
          if (!this.sourceBuffer.updating && this.mediaSource.readyState === 'open') {
            this.mediaSource.endOfStream();
          }
        });
      };

    },
    readChunk(i, videochunk_Array_buffer) {
      this.sourceBuffer.appendBuffer(new Uint8Array(videochunk_Array_buffer));
      console.log('Appending chunk: ' + i);
    }
  }
};