class WorkerThreadBreaker extends Thread {
    private boolean _canStop = false;
    private int msTimeout = 0;

    public WorkerThreadBreaker(int msTimeout) {
        this.msTimeout = msTimeout;
        this.start();
    }

    public String getMeta() {
        return "Timeout = " + this.msTimeout;
    }

    synchronized public boolean isCanStop() {
        return this._canStop;
    }

    @Override
    public void run() {
        try {
            Thread.sleep(this.msTimeout);
        } catch (InterruptedException error) {
            error.printStackTrace();
        } finally {
            this._canStop = true;
        }
    }
}