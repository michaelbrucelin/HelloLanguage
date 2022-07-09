/******************************************************************************
 *  Compilation:  javac StdAudio.java
 *  Execution:    java StdAudio
 *  Dependencies: none
 *  
 *  Simple library for reading, writing, and manipulating .wav files.
 *
 *
 *  Limitations
 *  -----------
 *    - Assumes the audio is monaural, little endian, with sampling rate
 *      of 44,100
 *    - read() does not currently support streamed audio, such as MIDI
 *    - check when reading .wav files from a .jar file ?
 *
 ******************************************************************************/

package edu.princeton.cs.algs4;

import javax.sound.sampled.Clip;

import java.io.File;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.io.IOException;

import java.net.URL;

import java.util.LinkedList;

import javax.sound.sampled.AudioFileFormat;
import javax.sound.sampled.AudioFormat;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.DataLine;
import javax.sound.sampled.LineUnavailableException;
import javax.sound.sampled.SourceDataLine;
import javax.sound.sampled.UnsupportedAudioFileException;

import javax.sound.sampled.LineListener;
import javax.sound.sampled.LineEvent;

/**
 *  The {@code StdAudio} class provides a basic capability for
 *  playing, reading, and saving audio.
 *  It uses a simple audio model that allows you
 *  to send one sample to the sound card at a time.
 *  Each sample is a real number between -1.0 and +1.0.
 *  The samples are played in real time using a sampling
 *  rate of 44,100 Hz.
 *  In addition to playing individual samples, standard audio supports
 *  reading and writing audio files and playing audio files in a background thread.
 *  <p>
 *  <b>Getting started.</b>
 *  To use this class, you must have {@code StdAudio.class} in your
 *  Java classpath. If you used our autoinstaller, you should be all set.
 *  Otherwise, either download
 *  <a href = "https://introcs.cs.princeton.edu/java/code/stdlib.jar">stdlib.jar</a>
 *  and add to your Java classpath or download
 *  <a href = "https://introcs.cs.princeton.edu/java/stdlib/StdAudio.java">StdAudio.java</a>
 *  and put a copy in your working directory.
 *  <p>
 *  Now, cut-and-paste the following short program into your editor:
 *  <pre>
 *   public class TestStdAudio {
 *       public static void main(String[] args) {
 *           double concertA = 440.0;
 *           for (int i = 0; i &lt; StdAudio.SAMPLING_RATE; i++) {
 *               double sample = 0.5 * Math.sin(2*Math.PI * freq * i / StdAudio.SAMPLE_RATE);
 *               StdAudio.play(sample);
 *           }
 *           StdAudio.close();
 *       }
 *   }
 *  </pre>
 *  If you compile and execute the program, you should hear a pure tone
 *  whose frequency is concert A.
 *  <p>
 *  <b>Reading and writing audio files.</b>
 *  You can read and write a audio file using the following:
 *  <ul>
 *  <li> {@link #read(String filename)}
 *  <li> {@link #save(String filename, double[] samples)}
 *  </ul>
 *  <p>
 *  The first method reads audio samples from an audio file
 *  (in either WAV, AU, or MIDI format)
 *  and returns them as a double array with values between -1.0 and 1.0.
 *  The second method saves the samples in the specified double array to an
 *  audio file (in either WAV, AU, or AIFF format).
 *  The file extensions corresponding to WAV, AU, AIFF, and MIDI files
 *  are {@code .wav}, {@code .au}, {@code .aiff}, and {@code .midi},
 *  respectively.
 *  The file format is assumed to use a sampling rate of 44,100 Hz,
 *  16 bits per sample, and monaural audio.
 *  
 *  <p>
 *  <b>Playing audio.</b>
 *  You can use the following three methods to play audio samples:
 *  <ul>
 *  <li> {@link #play(double sample)}
 *  <li> {@link #play(double[] samples)}
 *  <li> {@link #play(String filename)}
 *  </ul>
 *  <p>
 *  Each method sends the specified sample (or samples) to the sound card.
 *  The individual samples are real numbers between -1.0 and +1.0. If a
 *  sample is outside this range, it will be <em>clipped</em> (rounded to
 *  -1.0 or +1.0). The samples are played in real time using a sampling
 *  rate of 44,100 Hz.
 *  <p>
 *  The third method supports playing the samples from a specified 
 *  audio file (in WAV, MIDI, or AU format). This can produce particularly
 *  striking programs with minimal code. For example, the following 
 *  code fragment plays a drum loop:
 *  <pre>
 *   while (true) {
 *       StdAudio.play("bass-drum.wav");
 *       StdAudio.play("snare-drum.wav");
 *   }
 *  </pre>
 *
 *  The individual audio files (such as bass-drum.wav and snare-drum.wav)
*   must be accessible to Java, typically
 *  by being in the same directory as the {@code .class} file.
 *  
 *  <p>
 *  <b>Playing audio in the background thread.</b>
 *  You can use the following methods to play audio in a background thread
 *  (e.g., as a background score in your program).
 *  <ul>
 *  <li> {@link #playInBackground(String filename)}
 *  <li> {@link #stopInBackground()}
 *  </ul>
 *  <p>
 *  Each call to the first method plays the specified sound in a separate background
 *  thread. Unlike with the {@link play} methods, your program will not wait
 *  for the samples to finish playing before continuing. 
 *  It supports playing audio files in WAV, AU, AIFF, or MIDI formats.
 *  It is possible to play
 *  multiple audio files simultaneously (in separate background threads). 
 *  The second method stops the playing of all audio in background threads.
 *  <p>
 *  <b>Closing standard audio.</b>
 *  On some systems, your Java program may terminate before all of the samples have been
 *  played. To prevent this, it is recommend that you call one of the following two
 *  method to indicate that you are done with using standard audio:
 *  <ul>
 *  <li> {@link #drain()}
 *  <li> {@link #close()}
 *  </ul>
 *  <p>
 *  The first method drain any samples queued to the sound card that have not yet been played.
 *  The second method also closes standard audio so that it cannot be used again in the same
 *  program.
 *  <p>
 *  <b>Reference.</b>
 *  For additional documentation,
 *  see <a href="https://introcs.cs.princeton.edu/15inout">Section 1.5</a> of
 *  <em>Computer Science: An Interdisciplinary Approach</em>
 *  by Robert Sedgewick and Kevin Wayne.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 */
public final class StdAudio {

    /**
     *  The sample rate: 44,100 Hz for CD quality audio.
     */
    public static final int SAMPLE_RATE = 44100;

    private static final int BYTES_PER_SAMPLE = 2;       // 16-bit audio
    private static final int BITS_PER_SAMPLE = 16;       // 16-bit audio
    private static final int MAX_16_BIT = 32768;
    private static final int SAMPLE_BUFFER_SIZE = 4096;

    private static final int MONO   = 1;
    private static final int STEREO = 2;
    private static final boolean LITTLE_ENDIAN = false;
    private static final boolean BIG_ENDIAN    = true;
    private static final boolean SIGNED        = true;
    private static final boolean UNSIGNED      = false;


    private static SourceDataLine line;   // to play the sound
    private static byte[] buffer;         // our internal buffer
    private static int bufferSize = 0;    // number of samples currently in internal buffer

    // queue of background runnables
    private static LinkedList<BackgroundRunnable> backgroundRunnables = new LinkedList<>();

    private StdAudio() {
        // can not instantiate
    }
   
    // static initializer
    static {
        init();
    }

    // open up an audio stream
    private static void init() {
        try {
            // 44,100 Hz, 16-bit audio, mono, signed PCM, little endian
            AudioFormat format = new AudioFormat((float) SAMPLE_RATE, BITS_PER_SAMPLE, MONO, SIGNED, LITTLE_ENDIAN);
            DataLine.Info info = new DataLine.Info(SourceDataLine.class, format);

            line = (SourceDataLine) AudioSystem.getLine(info);
            line.open(format, SAMPLE_BUFFER_SIZE * BYTES_PER_SAMPLE);
            
            // the internal buffer is a fraction of the actual buffer size, this choice is arbitrary
            // it gets divided because we can't expect the buffered data to line up exactly with when
            // the sound card decides to push out its samples.
            buffer = new byte[SAMPLE_BUFFER_SIZE * BYTES_PER_SAMPLE/3];
        }
        catch (LineUnavailableException e) {
            System.out.println(e.getMessage());
        }

        // no sound gets made before this call
        line.start();
    }

    // get an AudioInputStream object from a file
    private static AudioInputStream getAudioInputStreamFromFile(String filename) {
        if (filename == null) {
            throw new IllegalArgumentException("filename is null");
        }

        try {
            // first try to read file from local file system
            File file = new File(filename);
            if (file.exists()) {
                return AudioSystem.getAudioInputStream(file);
            }

            // resource relative to .class file
            InputStream is1 = StdAudio.class.getResourceAsStream(filename);
            if (is1 != null) {
                return AudioSystem.getAudioInputStream(is1);
            }

            // resource relative to classloader root
            InputStream is2 = StdAudio.class.getClassLoader().getResourceAsStream(filename);
            if (is2 != null) {
                return AudioSystem.getAudioInputStream(is2);
            }

            // from URL (including jar file)
            URL url = new URL(filename);
            if (url != null) {
                return AudioSystem.getAudioInputStream(url);
            }

            // give up
            else {
                throw new IllegalArgumentException("could not read '" + filename + "'");
            }
        }
        catch (IOException e) {
            throw new IllegalArgumentException("could not read '" + filename + "'", e);
        }
        catch (UnsupportedAudioFileException e) {
            throw new IllegalArgumentException("file of unsupported audio format: '" + filename + "'", e);
        }
    }

    /**
     * Sends any queued samples to the sound card.
     */
    public static void drain() {
        if (bufferSize > 0) {
            line.write(buffer, 0, bufferSize);
            bufferSize = 0;
        }
        line.drain();
    }


    /**
     * Closes standard audio.
     */
    public static void close() {
        drain();
        line.stop();
    }
    
    /**
     * Writes one sample (between -1.0 and +1.0) to standard audio.
     * If the sample is outside the range, it will be clipped
     * (rounded to -1.0 or +1.0).
     *
     * @param  sample the sample to play
     * @throws IllegalArgumentException if the sample is {@code Double.NaN}
     */
    public static void play(double sample) {
        if (Double.isNaN(sample)) throw new IllegalArgumentException("sample is NaN");

        // clip if outside [-1, +1]
        if (sample < -1.0) sample = -1.0;
        if (sample > +1.0) sample = +1.0;

        // convert to bytes
        short s = (short) (MAX_16_BIT * sample);
        if (sample == 1.0) s = Short.MAX_VALUE;   // special case since 32768 not a short
        buffer[bufferSize++] = (byte) s;
        buffer[bufferSize++] = (byte) (s >> 8);   // little endian

        // send to sound card if buffer is full        
        if (bufferSize >= buffer.length) {
            line.write(buffer, 0, buffer.length);
            bufferSize = 0;
        }
    }

    /**
     * Writes the array of samples (between -1.0 and +1.0) to standard audio.
     * If a sample is outside the range, it will be clipped.
     *
     * @param  samples the array of samples to play
     * @throws IllegalArgumentException if any sample is {@code Double.NaN}
     * @throws IllegalArgumentException if {@code samples} is {@code null}
     */
    public static void play(double[] samples) {
        if (samples == null) throw new IllegalArgumentException("argument to play() is null");
        for (int i = 0; i < samples.length; i++) {
            play(samples[i]);
        }
    }

    /**
     * Plays an audio file (in .wav, .mid, or .au format) and wait for it to finish.
     *
     * @param filename the name of the audio file
     * @throws IllegalArgumentException if unable to play {@code filename}
     * @throws IllegalArgumentException if {@code filename} is {@code null}
     */
    public static void play(String filename) {
        double[] samples = read(filename);
        play(samples);
    }

    /**
     * Reads audio samples from a file (in .wav or .au format) and returns
     * them as a double array with values between -1.0 and +1.0.
     * The audio file must be 16-bit with a sampling rate of 44,100.
     * It can be mono or stereo.
     *
     * @param  filename the name of the audio file
     * @return the array of samples
     */
    public static double[] read(String filename) {

        // make sure that AudioFormat is 16-bit, 44,100 Hz, little endian
        final AudioInputStream ais = getAudioInputStreamFromFile(filename);
        AudioFormat audioFormat = ais.getFormat();

        // require sampling rate = 44,100 Hz
        if (audioFormat.getSampleRate() != SAMPLE_RATE) {
            throw new IllegalArgumentException("StdAudio.read() currently supports only a sample rate of " + SAMPLE_RATE + " Hz\n"
                                             + "audio format: " + audioFormat);
        }

        // require 16-bit audio
        if (audioFormat.getSampleSizeInBits() != BITS_PER_SAMPLE) {
            throw new IllegalArgumentException("StdAudio.read() currently supports only " + BITS_PER_SAMPLE + "-bit audio\n"
                                             + "audio format: " + audioFormat);
        }

        byte[] bytes = null;

        try {
            long frameLength = ais.getFrameLength();
            int frameSize = audioFormat.getFrameSize();
            if (frameLength * frameSize >= Integer.MAX_VALUE) {
                throw new IllegalArgumentException("the audio file is too large to store in memory: " + (frameLength * frameSize));
            }
            int numBytesToRead = (int) frameLength * frameSize;
            bytes = new byte[numBytesToRead];
            int numBytesRead = ais.read(bytes);
            if (numBytesRead != numBytesToRead) {
                throw new IllegalStateException("read only " + numBytesRead + " of " + numBytesToRead + " bytes"); 
            }
        }
        catch (IOException ioe) {
            throw new IllegalArgumentException("could not read '" + filename + "'", ioe);
        }

        int n = bytes.length;

        // little endian, mono
        if (audioFormat.getChannels() == MONO && !audioFormat.isBigEndian()) {
            double[] data = new double[n/2];
            for (int i = 0; i < n/2; i++) {
                // little endian, mono
                data[i] = ((short) (((bytes[2*i+1] & 0xFF) << 8) | (bytes[2*i] & 0xFF))) / ((double) MAX_16_BIT);
            }
            return data;
        }

        // big endian, mono
        else if (audioFormat.getChannels() == MONO && audioFormat.isBigEndian()) {
            double[] data = new double[n/2];
            for (int i = 0; i < n/2; i++) {
                // little endian, mono
                data[i] = ((short) (((bytes[2*i] & 0xFF) << 8) | (bytes[2*i+1] & 0xFF))) / ((double) MAX_16_BIT);
            }
            return data;
        }

        // little endian, stereo
        else if (audioFormat.getChannels() == STEREO && !audioFormat.isBigEndian()) {
            double[] data = new double[n/4];
            for (int i = 0; i < n/4; i++) {
                double left  = ((short) (((bytes[4*i + 1] & 0xFF) << 8) | (bytes[4*i + 0] & 0xFF))) / ((double) MAX_16_BIT);
                double right = ((short) (((bytes[4*i + 3] & 0xFF) << 8) | (bytes[4*i + 2] & 0xFF))) / ((double) MAX_16_BIT);
                data[i] = (left + right) / 2.0;
            }
            return data;
        }

        // big endian, stereo
        else if (audioFormat.getChannels() == STEREO && audioFormat.isBigEndian()) {
            double[] data = new double[n/4];
            for (int i = 0; i < n/4; i++) {
                double left  = ((short) (((bytes[4*i + 0] & 0xFF) << 8) | (bytes[4*i + 1] & 0xFF))) / ((double) MAX_16_BIT);
                double right = ((short) (((bytes[4*i + 2] & 0xFF) << 8) | (bytes[4*i + 3] & 0xFF))) / ((double) MAX_16_BIT);
                data[i] = (left + right) / 2.0;
            }
            return data;
        }

        // TODO: other formats
        else throw new IllegalStateException("audio format is neither mono or stereo");
    }

    /**
     * Saves the double array as an audio file (using WAV, AU, or AIFF format).
     * The filename extension type must be either {@code .wav}, {@code .au},
     * or {@code .aiff}.
     * The format uses a sampling rate of 44,100 Hz, 16-bit audio,
     * mono, signed PCM, ands little Endian.
     *
     * @param  filename the name of the audio file
     * @param  samples the array of samples
     * @throws IllegalArgumentException if unable to save {@code filename}
     * @throws IllegalArgumentException if {@code samples} is {@code null}
     * @throws IllegalArgumentException if {@code filename} is {@code null}
     * @throws IllegalArgumentException if {@code filename} extension is not {@code .wav}
     *         or {@code .au}
     */
    public static void save(String filename, double[] samples) {
        if (filename == null) {
            throw new IllegalArgumentException("filename is null");
        }
        if (samples == null) {
            throw new IllegalArgumentException("samples[] is null");
        }

        // assumes 16-bit samples with sample rate = 44,100 Hz
        // use 16-bit audio, mono, signed PCM, little Endian
        AudioFormat format = new AudioFormat(SAMPLE_RATE, 16, MONO, SIGNED, LITTLE_ENDIAN);
        byte[] data = new byte[2 * samples.length];
        for (int i = 0; i < samples.length; i++) {
            int temp = (short) (samples[i] * MAX_16_BIT);
            if (samples[i] == 1.0) temp = Short.MAX_VALUE;   // special case since 32768 not a short
            data[2*i + 0] = (byte) temp;
            data[2*i + 1] = (byte) (temp >> 8);   // little endian
        }

        // now save the file
        try {
            ByteArrayInputStream bais = new ByteArrayInputStream(data);
            AudioInputStream ais = new AudioInputStream(bais, format, samples.length);

            if (filename.endsWith(".wav") || filename.endsWith(".WAV")) {
                AudioSystem.write(ais, AudioFileFormat.Type.WAVE, new File(filename));
            }
            else if (filename.endsWith(".au") || filename.endsWith(".AU")) {
                AudioSystem.write(ais, AudioFileFormat.Type.AU, new File(filename));
            }
            else if (filename.endsWith(".aif") || filename.endsWith(".aiff") ||
                     filename.endsWith(".AIF") || filename.endsWith(".AIFF")) {
                AudioSystem.write(ais, AudioFileFormat.Type.AIFF, new File(filename));
            }
            else {
                throw new IllegalArgumentException("file type for saving must be .wav, .au, or .aiff");
            }
        }
        catch (IOException ioe) {
            throw new IllegalArgumentException("unable to save file '" + filename + "'", ioe);
        }
    }

    /**
     * Stops the playing of all audio files in background threads.
     */
    public static synchronized void stopInBackground() {
        for (BackgroundRunnable runnable : backgroundRunnables) {
            runnable.stop();
        }
        backgroundRunnables = new LinkedList<>();
    }

    public static synchronized void playInBackground(final String filename) {
        BackgroundRunnable runnable = new BackgroundRunnable(filename);
        new Thread(runnable).start();
        backgroundRunnables.add(runnable);
    }

    private static class BackgroundRunnable implements Runnable {
        private volatile boolean exit = false;
        private final String filename;

        public BackgroundRunnable(String filename) {
            this.filename = filename;
        }
    
        // https://www3.ntu.edu.sg/home/ehchua/programming/java/J8c_PlayingSound.html
        // play a wav or aif file
        // javax.sound.sampled.Clip fails for long clips (on some systems)
        public void run() {
            AudioInputStream ais = getAudioInputStreamFromFile(filename);

            SourceDataLine line = null;
            int BUFFER_SIZE = 4096; // 4K buffer

            try {
                AudioFormat audioFormat = ais.getFormat();
                DataLine.Info info = new DataLine.Info(SourceDataLine.class, audioFormat);
                line = (SourceDataLine) AudioSystem.getLine(info);
                line.open(audioFormat);
                line.start();
                byte[] samples = new byte[BUFFER_SIZE];
                int count = 0;
                while (!exit && (count = ais.read(samples, 0, BUFFER_SIZE)) != -1) {
                    line.write(samples, 0, count);
                }
            }
            catch (IOException e) {
                e.printStackTrace();
            }
            catch (LineUnavailableException e) {
                e.printStackTrace();
            }
            finally {
                if (line != null) {
                    line.drain();
                    line.close();
                }
            }
        }

        public void stop() {
            exit = true;
        }
    }


    /**
     * Loops an audio file (in .wav, .mid, or .au format) in a background thread.
     *
     * @param filename the name of the audio file
     * @throws IllegalArgumentException if {@code filename} is {@code null}
     * @deprecated to be removed in a future update, as it doesn't interact
     *             well with {@link #playInBackground(String filename)} or
     *             {@link #stopInBackground()}.
     */
    @Deprecated
    public static synchronized void loopInBackground(String filename) {
        if (filename == null) throw new IllegalArgumentException();

        final AudioInputStream ais = getAudioInputStreamFromFile(filename);

        try {
            Clip clip = AudioSystem.getClip();
            // Clip clip = (Clip) AudioSystem.getLine(new Line.Info(Clip.class));
            clip.open(ais);
            clip.loop(Clip.LOOP_CONTINUOUSLY);
        }
        catch (LineUnavailableException e) {
            e.printStackTrace();
        }
        catch (IOException e) {
            e.printStackTrace();
        }

        // keep JVM open
        new Thread(new Runnable() {
            public void run() {
                while (true) {
                    try {
                       Thread.sleep(1000);
                    }
                    catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        }).start();
    }


   /***************************************************************************
    * Unit tests {@code StdAudio}.
    ***************************************************************************/

    // create a note (sine wave) of the given frequency (Hz), for the given
    // duration (seconds) scaled to the given volume (amplitude)
    private static double[] note(double hz, double duration, double amplitude) {
        int n = (int) (StdAudio.SAMPLE_RATE * duration);
        double[] a = new double[n+1];
        for (int i = 0; i <= n; i++)
            a[i] = amplitude * Math.sin(2 * Math.PI * i * hz / StdAudio.SAMPLE_RATE);
        return a;
    }

    /**
     * Test client - play an A major scale to standard audio.
     *
     * @param args the command-line arguments
     */
    /**
     * Test client - play an A major scale to standard audio.
     *
     * @param args the command-line arguments
     */
    public static void main(String[] args) {
        
        // 440 Hz for 1 sec
        double freq = 440.0;
        for (int i = 0; i <= StdAudio.SAMPLE_RATE; i++) {
            StdAudio.play(0.5 * Math.sin(2*Math.PI * freq * i / StdAudio.SAMPLE_RATE));
        }
        
        // scale increments
        int[] steps = { 0, 2, 4, 5, 7, 9, 11, 12 };
        for (int i = 0; i < steps.length; i++) {
            double hz = 440.0 * Math.pow(2, steps[i] / 12.0);
            StdAudio.play(note(hz, 1.0, 0.5));
        }


        // need to call this in non-interactive stuff so the program doesn't terminate
        // until all the sound leaves the speaker.
        StdAudio.close(); 
    }
}

/******************************************************************************
 *  Copyright 2002-2020, Robert Sedgewick and Kevin Wayne.
 *
 *  This file is part of algs4.jar, which accompanies the textbook
 *
 *      Algorithms, 4th edition by Robert Sedgewick and Kevin Wayne,
 *      Addison-Wesley Professional, 2011, ISBN 0-321-57351-X.
 *      http://algs4.cs.princeton.edu
 *
 *
 *  algs4.jar is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  algs4.jar is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with algs4.jar.  If not, see http://www.gnu.org/licenses.
 ******************************************************************************/
