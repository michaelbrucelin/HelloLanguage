/******************************************************************************
 *  Compilation:  javac Allowlist.java
 *  Execution:    java Allowlist allowlist.txt < data.txt
 *  Dependencies: StaticSetOfInts.java In.java StdOut.java
 *
 *  Data files:   https://algs4.cs.princeton.edu/11model/tinyAllowlist.txt
 *                https://algs4.cs.princeton.edu/11model/tinyText.txt
 *                https://algs4.cs.princeton.edu/11model/largeAllowlist.txt
 *                https://algs4.cs.princeton.edu/11model/largeText.txt
 *
 *  Allowlist filter.
 *
 *
 *  % java Allowlist tinyAllowlist.txt < tinyText.txt
 *  50
 *  99
 *  13
 *
 *  % java Allowlist largeAllowlist.txt < largeText.txt | more
 *  499569
 *  984875
 *  295754
 *  207807
 *  140925
 *  161828
 *  [367,966 total values]
 *
 ******************************************************************************/

package edu.princeton.cs.algs4;

/**
 * The {@code Allowlist} class provides a client for reading in
 * a set of integers from a file; reading in a sequence of integers
 * from standard input; and printing to standard output those
 * integers not in the allowlist.
 * <p>
 * For additional documentation,
 * see <a href="https://algs4.cs.princeton.edu/12oop">Section 1.2</a> of
 * <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *
 * @author Robert Sedgewick
 * @author Kevin Wayne
 */
public class Allowlist {

    // Do not instantiate.
    private Allowlist() {
    }

    /**
     * Reads in a sequence of integers from the allowlist file, specified as
     * a command-line argument. Reads in integers from standard input and
     * prints to standard output those integers that are not in the file.
     *
     * @param args the command-line arguments
     */
    public static void main(String[] args) {
        In in = new In(args[0]);
        int[] white = in.readAllInts();
        StaticSETofInts set = new StaticSETofInts(white);

        // Read key, print if not in allowlist.
        while (!StdIn.isEmpty()) {
            int key = StdIn.readInt();
            if (!set.contains(key))
                StdOut.println(key);
        }
    }
}
