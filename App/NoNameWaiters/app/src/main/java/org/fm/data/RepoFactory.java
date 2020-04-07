package org.fm.data;

public class RepoFactory {
    public static Repository getRepo(){
        return new FakeRepo();
    }
}
